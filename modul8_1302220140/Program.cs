using System;
using System.IO;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string bahasa;
        int uang;

        Bank defaultConf = new Bank();

        

        Console.Write($"Masukan jumlah uang yang ingin di-transfer {defaultConf}: ");
        Console.WriteLine

    }
}

public class Bank
{
    public string lang { get; set; }
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }

    public string method { get; set; }
    public string EN { get; set; }
    public string ID { get; set; }

    public Bank() { }

    public Bank(string lang, int threshold, int low_fee, int high_fee, string method, string EN, string ID)
    {
        this.lang = lang;
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
        this.method = method;
        this.ID = ID;
        this.EN = EN;
    }

    
}


public class bankTransfer
{
    public Bank conf { get; private set; }
    private const string filePath = @"E:\TELKOM UNIVERSITY\TUGAS KULIAH\KONSTRUKSI PERANGKAT LUNAK (KPL)\1302220140_MOD8_JURNAL_RDA1\modul8_1302220140\\bankTransferConfig.json";

    public bankTransfer()
    {
        try
        {
            ReadConfig();
        }
        catch (FileNotFoundException)
        {
            WriteNewConfig();
        }
        catch (JsonException)
        {
            Console.WriteLine("File konfigurasi tidak valid. Membuat konfigurasi default.");
            WriteNewConfig();
        }
    }

    private void ReadConfig()
    {
        string jsonData = File.ReadAllText(filePath);
        conf = JsonSerializer.Deserialize<Bank>(jsonData);
    }



    private void WriteNewConfig()
    {
        JsonSerializerOptions opts = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        string jsonString = JsonSerializer.Serialize(Bank, opts);
        File.WriteAllText(filePath, jsonString);
    }



}
