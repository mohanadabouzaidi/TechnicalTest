using System;

namespace TechnicalTestIngenico
{
    class Program
    {
        static void Main(string[] args)
        {
            // if you want to add decimal number, please use the ',' and not the '.'
            var result = Report("P65\\nR15\\nF3\\nL\\nP45\\n");

            Console.WriteLine(result);
        }

        public static string Report(string input)
        {
            //there is no validation bcs it is not needed in the exercice.
            double balance = 0;
            double transactionFees = 0;
            double refund = 0;
            double totalFees = 0;
            double transferedToRecipient = 0;

            //btw we have to check if the input is longer than 0
            if(input.Length > 0)
            {
                //cut the operations based on the '\n' character
                string[] operations = input.Split("\\n");

                foreach (var ope in operations)
                {
                    if(ope.Length > 0)
                    {
                        switch (ope[0])
                        {
                            case 'P':
                                balance += Convert.ToDouble(ope.Substring(1));
                                break;
                            case 'R':
                                balance -= Convert.ToDouble(ope.Substring(1));
                                refund += Convert.ToDouble(ope.Substring(1));
                                break;
                            case 'F':
                                transactionFees += Convert.ToDouble(ope.Substring(1));
                                break;
                            case 'L':
                                transferedToRecipient = balance - transactionFees;
                                totalFees += transactionFees;
                                balance = 0;
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
                input = string.Format("Balance: {0} euros \n" +
                                      "Total fees: {1} euros \n" +
                                      "Transferred to recipient: {2} euros"
                                      , balance.ToString(),
                                      transactionFees.ToString(),
                                      transferedToRecipient.ToString()
                                      );
            }

            return input;
        }
    }
}
