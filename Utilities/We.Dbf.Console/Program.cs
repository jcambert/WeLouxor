// See https://aka.ms/new-console-template for more information
using We.Dbf;
//Page(\d)|Type('SF'|'PF')|Of(\d)|Op(\d)|Client(\w)|Article(\w)|Quantite(\d)|AR(\d)|Pv Article Tete(\d)|Pu Gamme(\d)|Pu Nomenc(\d)|Ct  Revient(Pu Gamme+Pu Nomenc)|Valo(Quantite*Ct  Revient)
const string table = "ppchar";
var dir = AppDomain.CurrentDomain.BaseDirectory;
var pathes=dir.Split(@"\")[..^6];
//Array.Resize(ref pathes, pathes.Length+2);
//pathes[^2] = "Database";
//pathes[^1] = "pparti.dbf";
var filename = $@"{Path.Combine(pathes)}\src\We.Louxor.Blazor\wwwroot\database\{table}.dbf";
DbfDocument doc = new DbfDocument(filename);
doc.From = 3813;
doc.To = 10;
doc.HeaderLoaded.Subscribe(h => {
    Console.WriteLine("Header is loaded");
});
doc.FieldsDescriptorLoaded.Subscribe(f => {
    Console.WriteLine("Field Descriptor loaded");
    Console.WriteLine($"There is {f.Count} Fields in {doc.TableName}");
    foreach (var field in f)
    {
        Console.WriteLine($"{field.Name}-{field.Type}:{field.DecimalCount}");
    }
});
doc.AllRecordsLoaded.Subscribe(doc => { Console.WriteLine("All records are loaded"); });
doc.RecordsLoaded.Subscribe(records =>
{
    Console.WriteLine($"{records.Count} are been loaded");

});
await doc.Load(false);
await doc.LoadRecords();
