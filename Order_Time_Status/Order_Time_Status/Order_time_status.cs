using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Order_Time_Status;
using System;
using System.Runtime.CompilerServices;
using ThirdParty.BouncyCastle.Utilities.IO.Pem;

var client = new MongoClient("mongodb://root:password@localhost:27117/");
IMongoDatabase _database = client.GetDatabase("workorders");
var collection = _database.GetCollection<WorkOrderDetails>("workorders");
Guid First_OrgId = new Guid("8e77524d-bb0f-40e3-b261-ac7e62dd0fc4");
Guid First_Workspace = new Guid("14e9d8f5-c9a6-4d69-8294-07da50b84fa9");
Guid Second_OrgId = new Guid("dfd36d2d-b6a6-4baf-8866-4e41bd5a31e8");
Guid Second_Workspace = new Guid("63146851-9545-47ee-a539-60857497e0ae");
Guid First_AssignedToId = new Guid("f6379763-ac91-4d20-900c-78adfacff88b");
Guid Second_AssignedToId = new Guid("896ff676-22a8-40de-8e0e-b8abd6999651");
Guid Third_AssignedToId = new Guid("4eb279db-8b21-4e9e-8c18-9ce4bc313c06");

//foreach (var statusval in Enum.GetValues(typeof(WorkOrderStatusDetails)))
//{
//    // First part of data

//    WorkOrderStatusDetails currentstatus = (WorkOrderStatusDetails)statusval;
//    var Firstfilter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == First_OrgId && x.Workspace == First_Workspace));
//    var Secondfilter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == Second_OrgId && x.Workspace == Second_Workspace));
//    var findoptions = new FindOptions<WorkOrderDetails> { Limit = 1000 };
//    var First_aggregates = new List<BsonDocument>()
//            {
//                new BsonDocument(
//                    "$match",
//                    Firstfilter.Render(BsonSerializer.SerializerRegistry.GetSerializer<WorkOrderDetails>(), BsonSerializer.SerializerRegistry)),
//                //new BsonDocument("$limit", 1000),
//        };
//    var First_pipeline = PipelineDefinition<WorkOrderDetails, WorkOrderDetails>.Create(First_aggregates);
//    var statusWatch = System.Diagnostics.Stopwatch.StartNew();
//    //var Firstdocuments = await collection.FindAsync(Firstfilter,findoptions);
//    var Firstdocuments = await collection.AggregateAsync(First_pipeline);
//    var FirstworkOrderCount = Firstdocuments.ToEnumerable().Count();
//    statusWatch.Stop();
//    var FirstelapsedMs = statusWatch.ElapsedMilliseconds;
//    Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}", currentstatus, First_OrgId, First_Workspace);
//    Console.WriteLine("Time Taken:{0}", FirstelapsedMs);
//    Console.WriteLine("The count is:{0}" + "\n", FirstworkOrderCount);

//    statusWatch.Reset();
//    // Second part of data 

//    var Second_aggregates = new List<BsonDocument>()
//            {
//                new BsonDocument(
//                    "$match",
//                    Secondfilter.Render(BsonSerializer.SerializerRegistry.GetSerializer<WorkOrderDetails>(), BsonSerializer.SerializerRegistry)),
//                //new BsonDocument("$limit", 1000),
//        };
//    var Second_pipeline = PipelineDefinition<WorkOrderDetails, WorkOrderDetails>.Create(Second_aggregates);
//    statusWatch = System.Diagnostics.Stopwatch.StartNew();
//    //var Seconddocuments = await collection.FindAsync(Secondfilter,findoptions);
//    var Seconddocuments = await collection.AggregateAsync(Second_pipeline);
//    var SecondworkOrderCount = Seconddocuments.ToEnumerable().Count();
//    statusWatch.Stop();
//    var SecondelapsedMs = statusWatch.ElapsedMilliseconds;
//    Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}", currentstatus, Second_OrgId, Second_Workspace);
//    Console.WriteLine("Time Taken:{0}", SecondelapsedMs);
//    Console.WriteLine("The count is :{0}" + "\n", SecondworkOrderCount);
//    statusWatch.Reset();
//}
foreach (var statusval in Enum.GetValues(typeof(WorkOrderStatusDetails)))
{
    // First part of data

    WorkOrderStatusDetails currentstatus = (WorkOrderStatusDetails)statusval;
    var First_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.OrgId == First_OrgId && x.Workspace == First_Workspace && x.AssignedTo == First_AssignedToId && x.Status == currentstatus));
    var Second_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.OrgId == Second_OrgId && x.Workspace == Second_Workspace && x.AssignedTo == First_AssignedToId && x.Status == currentstatus));
    //var Third_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == First_OrgId && x.Workspace == First_Workspace && x.AssignedTo == Second_AssignedToId));
    //var Fourth_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == Second_OrgId && x.Workspace == Second_Workspace && x.AssignedTo == Second_AssignedToId));
    //var Fifth_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == First_OrgId && x.Workspace == First_Workspace && x.AssignedTo == Third_AssignedToId));
    //var Sixth_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.Status == currentstatus && x.OrgId == Second_OrgId && x.Workspace == Second_Workspace && x.AssignedTo == Third_AssignedToId));
    var findoptions = new FindOptions<WorkOrderDetails> { Limit = 1000 };
    //var First_aggregates = new List<BsonDocument>()
    //        {
    //            new BsonDocument(
    //                "$match",
    //                First_filter.Render(BsonSerializer.SerializerRegistry.GetSerializer<WorkOrderDetails>(), BsonSerializer.SerializerRegistry)),
    //            //new BsonDocument("$limit", 1000),
    //    };
    //var First_pipeline = PipelineDefinition<WorkOrderDetails, WorkOrderDetails>.Create(First_aggregates);

    var statusWatch = System.Diagnostics.Stopwatch.StartNew();
    var Firstdocuments = await collection.FindAsync(First_filter, findoptions);
    //var Firstdocuments = await collection.AggregateAsync(First_pipeline);
    //var Firstdocuments = await collection.FindAsync(First_filter);
    var FirstworkOrderCount = Firstdocuments.ToEnumerable().Count();
    statusWatch.Stop();
    var FirstelapsedMs = statusWatch.ElapsedMilliseconds;
    Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, First_OrgId, First_Workspace, First_AssignedToId);
    Console.WriteLine("Time Taken :{0}", FirstelapsedMs);
    Console.WriteLine("The count is :{0}" + "\n", FirstworkOrderCount);

    statusWatch.Reset();
    // Second part of data 

    //var Second_aggregates = new List<BsonDocument>()
    //        {
    //            new BsonDocument(
    //                "$match",
    //                First_filter.Render(BsonSerializer.SerializerRegistry.GetSerializer<WorkOrderDetails>(), BsonSerializer.SerializerRegistry)),
    //            //new BsonDocument("$limit", 1000),
    //    };
    //var Second_pipeline = PipelineDefinition<WorkOrderDetails, WorkOrderDetails>.Create(Second_aggregates);

    statusWatch = System.Diagnostics.Stopwatch.StartNew();
    var Seconddocuments = await collection.FindAsync(Second_filter, findoptions);
    //var Seconddocuments = await collection.FindAsync(Second_filter);
    //var Seconddocuments = await collection.AggregateAsync(Second_pipeline);
    var SecondworkOrderCount = Seconddocuments.ToEnumerable().Count();
    statusWatch.Stop();
    var SecondelapsedMs = statusWatch.ElapsedMilliseconds;
    Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, Second_OrgId, Second_Workspace, First_AssignedToId);
    Console.WriteLine("Time Taken:{0}", SecondelapsedMs);
    Console.WriteLine("The count is :{0}" + "\n", SecondworkOrderCount);

    statusWatch.Reset();
    // Second part of data 

    //statusWatch = System.Diagnostics.Stopwatch.StartNew();
    //var Thirddocuments = await collection.FindAsync(Third_filter, findoptions);
    ////var Thirddocuments = await collection.FindAsync(Third_filter);
    //var ThirdworkOrderCount = Thirddocuments.ToEnumerable().Count();
    //statusWatch.Stop();
    //var ThirdelapsedMs = statusWatch.ElapsedMilliseconds;
    //Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, Second_OrgId, Second_Workspace, Second_AssignedToId);
    //Console.WriteLine("Time Taken:{0}", ThirdelapsedMs);
    //Console.WriteLine("The count is :{0}" + "\n", ThirdworkOrderCount);

    //statusWatch.Reset();
    //// Second part of data 

    //statusWatch = System.Diagnostics.Stopwatch.StartNew();
    //var Fourthdocuments = await collection.FindAsync(Fourth_filter, findoptions);
    ////var Fourthdocuments = await collection.FindAsync(Second_filter);
    //var FourthworkOrderCount = Fourthdocuments.ToEnumerable().Count();
    //statusWatch.Stop();
    //var FourthelapsedMs = statusWatch.ElapsedMilliseconds;
    //Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, Second_OrgId, Second_Workspace, Second_AssignedToId);
    //Console.WriteLine("Time Taken:{0}", FourthelapsedMs);
    //Console.WriteLine("The count is :{0}" + "\n", FourthworkOrderCount);

    //statusWatch.Reset();
    //// Second part of data 

    //statusWatch = System.Diagnostics.Stopwatch.StartNew();
    //var Fifthdocuments = await collection.FindAsync(Fifth_filter, findoptions);
    ////var Fifthdocuments = await collection.FindAsync(Fifth_filter);
    //var FifthworkOrderCount = Fifthdocuments.ToEnumerable().Count();
    //statusWatch.Stop();
    //var FifthelapsedMs = statusWatch.ElapsedMilliseconds;
    //Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, Second_OrgId, Second_Workspace, Third_AssignedToId);
    //Console.WriteLine("Time Taken:{0}", FifthelapsedMs);
    //Console.WriteLine("The count is :{0}" + "\n", FifthworkOrderCount);

    //statusWatch.Reset();
    //// Second part of data 

    //statusWatch = System.Diagnostics.Stopwatch.StartNew();
    //var Sixthdocuments = await collection.FindAsync(Sixth_filter, findoptions);
    ////var Sixthdocuments = await collection.FindAsync(Sixth_filter);
    //var SixthworkOrderCount = Sixthdocuments.ToEnumerable().Count();
    //statusWatch.Stop();
    //var SixthelapsedMs = statusWatch.ElapsedMilliseconds;
    //Console.WriteLine("Status :{0}" + "\n" + "OrgId :{1}" + "\n" + "Workspace :{2}" + "\n" + "AssignedTo Id :{3}", currentstatus, Second_OrgId, Second_Workspace, Third_AssignedToId);
    //Console.WriteLine("Time Taken:{0}", SixthelapsedMs);
    //Console.WriteLine("The count is :{0}" + "\n", SixthworkOrderCount);

    //statusWatch.Reset();
}





//foreach (var statusval in Enum.GetValues(typeof(WorkOrderStatusDetails)))
//{
//    WorkOrderStatusDetails currentstatus = (WorkOrderStatusDetails)statusval;
//    var filter = Builders<WorkOrderDetails>.Filter.Where(x => x.status == currentstatus);
//    var findoptions = new findoptions<WorkOrderDetails> { limit = 1000 };
//    var statuswatch = system.diagnostics.stopwatch.startnew();
//    var documents = await collection.findasync(filter, findoptions);
//    //var documents = await collection.findasync(filter);
//    //var workorderlist = documents.toenumerable().count();
//    statuswatch.stop();
//    var elapsedms = statuswatch.elapsedmilliseconds;
//    console.writeline("the time taken for status {0} is:", currentstatus);
//    console.writeline(elapsedms);
//    statuswatch.reset();
//}

//var findOptions = new FindOptions<WorkOrderDetails> { Limit = 1000 };
////Guid First_OrgId = new Guid("8e77524d-bb0f-40e3-b261-ac7e62dd0fc4");
////Guid First_Workspace = new Guid("14e9d8f5-c9a6-4d69-8294-07da50b84fa9");
//var First_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.OrgId == First_OrgId && x.Workspace == First_Workspace && x.AssignedTo == First_AssignedToId));
//var FirststatusWatch = System.Diagnostics.Stopwatch.StartNew();
//var Firstdocuments = await collection.FindAsync(First_filter, findOptions);
////var Firstdocuments = await collection.FindAsync(First_filter);
//var FirstworkOrderList = Firstdocuments.ToEnumerable().Count();
//FirststatusWatch.Stop();
//var FirstelapsedMs = FirststatusWatch.ElapsedMilliseconds;
//Console.WriteLine("First Assigned To Id :{0}", First_AssignedToId);
//Console.WriteLine("Count First Assigned To :{0}",FirstworkOrderList);
//Console.WriteLine("The time taken for getting the details of first OrgID and Workspace:{0}", FirstelapsedMs);

////Guid Second_OrgId = new Guid("dfd36d2d-b6a6-4baf-8866-4e41bd5a31e8");
////Guid Second_Workspace = new Guid("63146851-9545-47ee-a539-60857497e0ae");
//var Second_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.OrgId == Second_OrgId && x.Workspace == Second_Workspace && x.AssignedTo == Second_AssignedToId));
////var findOptions = new FindOptions<WorkOrderDetails> { Limit = 1000 };
//var SecondstatusWatch = System.Diagnostics.Stopwatch.StartNew();
//var Seconddocuments = await collection.FindAsync(Second_filter, findOptions);
////var Seconddocuments = await collection.FindAsync(Second_filter);
//var SecondworkOrderList = Seconddocuments.ToEnumerable().Count();
//SecondstatusWatch.Stop();
//var SecondelapsedMs = SecondstatusWatch.ElapsedMilliseconds;
//Console.WriteLine("First Assigned To Id :{0}", Second_AssignedToId);
//Console.WriteLine("Count First Assigned To :{0}", SecondworkOrderList);
//Console.WriteLine("The time taken for getting the details of first OrgID and Workspace:{0}", SecondelapsedMs);

////Guid Second_OrgId = new Guid("dfd36d2d-b6a6-4baf-8866-4e41bd5a31e8");
////Guid Second_Workspace = new Guid("63146851-9545-47ee-a539-60857497e0ae");
//var Third_filter = Builders<WorkOrderDetails>.Filter.Where(x => (x.OrgId == Second_OrgId && x.Workspace == Second_Workspace && x.AssignedTo == Third_AssignedToId));
////var findOptions = new FindOptions<WorkOrderDetails> { Limit = 1000 };
//var ThirdstatusWatch = System.Diagnostics.Stopwatch.StartNew();
//var Thirddocuments = await collection.FindAsync(Third_filter, findOptions);
////var Thirddocuments = await collection.FindAsync(Second_filter);
//var ThirdworkOrderList = Thirddocuments.ToEnumerable().Count();
//ThirdstatusWatch.Stop();
//var ThirdelapsedMs = ThirdstatusWatch.ElapsedMilliseconds;
//Console.WriteLine("First Assigned To Id :{0}", Third_AssignedToId);
//Console.WriteLine("Count First Assigned To :{0}", ThirdworkOrderList);
//Console.WriteLine("The time taken for getting the details of first OrgID and Workspace:{0}", ThirdelapsedMs);