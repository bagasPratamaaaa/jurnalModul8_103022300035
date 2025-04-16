using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace jurnalModul8_103022300035
{
    class Program
    {
        static void Main(string[] args)
        {
            int biayaTransfer = 0;
            string confirm = "";
            string transfermethod = "";
            BankTransferConfig config = new BankTransferConfig();

            if (config.lang == "en")
            {
                Console.Write($"Please insert the amount of money to transfer: ");
            } else
            {
                Console.Write($"Masukkan jumlah uang yang akan di-transfer: ");
            }

            int amount = int.Parse( Console.ReadLine() );
            if (amount <= config.transfer.threshold)

            {
                biayaTransfer = config.transfer.low_fee;
                amount += biayaTransfer;
            }
            else
            {
                biayaTransfer = config.transfer.high_fee;
                amount += biayaTransfer;
            }

            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer fee: {biayaTransfer}, Total amount: {amount}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer: {biayaTransfer}, Total biaya: {amount}");
            }

            if (config.lang == "en")
            {
                Console.WriteLine($"Select method transfer: ");
            }
            else
            {
                Console.WriteLine($"Pilih metode transfer: ");
            }

            for (int i = 0; i < config.method.Length; i++)
            {
                Console.WriteLine($"{i+1}. {config.method[i]}");
            }

            transfermethod = Console.ReadLine();

            if (config.lang == "en")
            {
                Console.Write($"Please type {config.confirmation.en} to confirm the transaction: ");
            }
            else
            {
                Console.Write($"Ketik {config.confirmation.id} untuk mengonfirmasi transaksi ");
            }

            confirm = Console.ReadLine();

            if (config.lang == "en" && confirm == "yes")
            {
                Console.WriteLine($"The transfer is completed");
            }
            else if (config.lang == "id" && confirm == "ya")
            {
                Console.WriteLine($"Proses transfer berhasil");
            } else
            {
                if (config.lang == "en")
                {
                    Console.WriteLine($"Transfer is cancelled");
                }
                else
                {
                    Console.WriteLine($"Transfer dibatalkan");
                }
            }

        }
    }
}
