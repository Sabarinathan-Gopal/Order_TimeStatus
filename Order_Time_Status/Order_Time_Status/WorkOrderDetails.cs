using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Time_Status
{
    public enum WorkOrderStatusDetails
    {
        Closed,
        New,
        Defined,
        Reviewed,
        Scheduled,
        InProgress,
        PendingApproval,
        Canceled
    };
    public enum WorkOrderType
    {
        TestRequest
    }
    internal class WorkOrderDetails
    {/// <summary>
     /// Id of the work order
     /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Id of the organisation where the work order belongs to.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid OrgId { get; set; }

        /// <summary>
        /// Id of the workspace where the work order belongs to.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid Workspace { get; set; }

        /// <summary>
        /// Type of the work order.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public WorkOrderType Type { get; set; }

        /// <summary>
        /// Current status of the work order.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public WorkOrderStatusDetails Status { get; set; }

        /// <summary>
        /// Name of the work order
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the work order and related details.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// User id from SystemLink user service of the user who created the work order
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// User id from SystemLink user service of the user who most recently updated the work order
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// User id from SystemLink user service of the user to whom the work order is assigned.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid? AssignedTo { get; set; }

        /// <summary>
        /// User id from SystemLink user service of the user who requested the work order.
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public Guid? RequestedBy { get; set; }

        /// <summary>
        /// ISO-8601 formatted timestamp indicating when the work order was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ISO-8601 formatted timestamp indicating when the work order was most recently updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Earliest date after which the work order could be executed.
        /// </summary>
        public DateTime? EarliestStartDate { get; set; }

        /// <summary>
        /// Date within which the work order has to be completed.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Properties associated with the work order as Key-value pairs
        /// </summary>
        [BsonDictionaryOptions(Representation = DictionaryRepresentation.ArrayOfDocuments)]
        public IDictionary<string, string> Properties { get; set; }
    }
}
