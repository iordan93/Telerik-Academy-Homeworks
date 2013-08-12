namespace _3.StringOccurrencesService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringOccurrencesService
    {

        [OperationContract]
        long CountOccurrences(string input, string pattern);
    }
}
