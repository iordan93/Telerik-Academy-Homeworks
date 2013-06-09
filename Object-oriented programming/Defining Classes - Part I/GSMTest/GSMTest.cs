using System;
using GSMData;

namespace GSMTest
{
    class GSMTest
    {
        static void Main()
        {
            GSM newGSM = new GSM("Nokia", "Asha 310", new Battery("Nokia", 100, 5, BatteryType.NiMH), new Display(0.5, 16000000), 219.99M, "Ivan Ivanov");

            GSM[] gsms = 
                        {
                            new GSM("Samsung", "Galaxy S2"),
                            new GSM("Windows", "Phone", display: new Display(5, 16000000), owner: "Stoyan Stoyanov", price: 500),
                            new GSM("HTC","Wildfire"),
                            newGSM,
                            GSM.IPhone4S
                        };
            foreach (var gsm in gsms)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }
        }
    }
}
