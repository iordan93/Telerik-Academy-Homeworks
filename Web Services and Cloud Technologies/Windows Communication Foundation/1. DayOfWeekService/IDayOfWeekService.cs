namespace _1.DayOfWeekService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string GetDayOfWeekInBulgarian(DateTime date);
    }
}
