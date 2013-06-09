using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses = new List<ICourse>();

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public List<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.courses = value;
            }
        }

        public Teacher(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder teacher = new StringBuilder();
            teacher.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.Courses.Count != 0)
            {
                teacher.AppendFormat("; Courses=[");
                for (int course = 0; course < this.Courses.Count; course++)
                {
                    if (course != this.Courses.Count - 1)
                    {
                        teacher.AppendFormat("{0}, ", this.Courses[course].Name);
                    }
                    else teacher.AppendFormat("{0}", this.Courses[course].Name);
                }
                teacher.Append("]");
            }
            return teacher.ToString();
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private List<string> topics = new List<string>();

        public CourseType CourseType
        {
            get
            {
                return this.courseType;
            }
            set
            {
                this.courseType = value;
            }
        }

        public List<string> Topics
        {
            get
            {
                return this.topics;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.topics = value;
            }
        }

        private CourseType courseType;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder course = new StringBuilder();
            course.AppendFormat("{0}: Name={1}", this.CourseType, this.Name);
            if (this.Teacher != null)
            {
                course.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.Topics.Count != 0)
            {
                course.AppendFormat("; Topics=[{0}]", String.Join(", ", this.Topics));
            }
            if (this is ILocalCourse) 
            {
                course.AppendFormat("; Lab={0}",(this as ILocalCourse).Lab);
            }
            if (this is IOffsiteCourse)
            {
                course.AppendFormat("; Town={0}",(this as IOffsiteCourse).Town);                
            }

            return course.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.lab = value;
            }
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
            this.CourseType = CourseType.LocalCourse;
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.town = value;
            }
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
            this.CourseType = CourseType.OffsiteCourse;
        }
    }

    public enum CourseType
    {
        LocalCourse,
        OffsiteCourse
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
