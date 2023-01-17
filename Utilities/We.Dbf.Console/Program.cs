// See https://aka.ms/new-console-template for more information
using We.Dbf;

Console.WriteLine("Hello, World!");
DbfDocument doc = new DbfDocument(@"E:\projets\WeLouxor\Database\cmlign.dbf");
doc.LimitRecordCountTo = 180;
doc.HeaderLoaded.Subscribe(h => { Console.WriteLine("Header is loaded"); });
doc.FieldsDescriptorLoaded.Subscribe(f => {
    Console.WriteLine("Field Descriptor loaded");
    Console.WriteLine($"There is {f.Count} Fields in {doc.TableName}");
});
doc.AllRecordsLoaded.Subscribe(doc => { Console.WriteLine("All records are loaded"); });
doc.RecordsLoaded.Subscribe(records =>
{
    Console.WriteLine($"{records.Count} are been loaded");

});
await doc.Load(false);
await doc.LoadRecords(100);
