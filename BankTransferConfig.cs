using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnalModul8_103022300035
{
    class BankTransferConfig
    {
        public string lang { get; set; } = "en";
        public Transfer transfer { get; set; }
        public string[] method { get; set; } = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];

        public Confirmation confirmation { get; set; }
        public BankTransferConfig() { }

        public BankTransferConfig(string lang, Transfer transfer, string[] method, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.method = method;
            this.confirmation = confirmation;
        }

        class UIConfig
        {
            public BankTransferConfig config;
            public const string filePath = @"../../../bank_transfer_config.json";
            public UIConfig() {
                try
                {
                    ReadConfigFile();
                } catch (Exception)
                {
                    setDefault();
                    WriteNewConfigFile();
                }
            }
            public BankTransferConfig ReadConfigFile()
            {
                string configJsonData = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
                return config;
            }

            public void setDefault()
            {
                config = new BankTransferConfig();
                config.lang = "en";
                config.transfer.threshold = 25000000;
                config.transfer.low_fee = 6500;
                config.transfer.high_fee = 15000;
                config.method = ["RTO(real - time)", "SKN", "RTGS", "BI FAST"];
                config.confirmation.en = "yes";
                config.confirmation.id = "ya";
            }

            public void WriteNewConfigFile()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(config, options);
                File.WriteAllText(filePath, jsonString);

            }
        }

        public class Transfer
        {
            public int threshold { get; set; } = 25000000;
            public int low_fee { get; set; } = 6500;
            public int high_fee { get; set; } = 15000;
        }

        public class Confirmation
        {
            public string en { get; set; } = "yes";
            public string id { get; set; } = "ya";
        }

    }
}
