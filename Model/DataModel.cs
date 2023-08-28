using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini_mes.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }

        //Navigation Properties
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
        public ICollection<Part> Parts { get; set; }
    }

    public class CustomerOrder
    {
        public int CustomerOrderID { get; set; }
        public string CustomerOrderNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime EstimateShipDate { get; set; }
        public DateTime FactoryShipDate { get; set; }
        public int OrderProgress { get; set; }
        public int Priority { get; set; }
        public int CustomerID { get; set; }

        //Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int RequiredQuantity { get; set; }
        public int CustomerOrderID { get; set; }
        public int ProductID { get; set; }

        //Navigation Properties
        public CustomerOrder CustomerOrder { get; set; }
        public Product Product { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int PartID { get; set; }
        public int ProcessFlowID { get; set; }

        //Navigation Properties
        public Part Part { get; set; }
        public ProcessFlow ProcessFlow { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class Part
    {
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public int CustomerID { get; set; }

        //Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class WorkOrder
    {
        public int WorkOrderID { get; set; }
        public string WorkOrderNumber { get; set; }
        public int LotQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int Progress { get; set; }
        public int OrderItemID { get; set; }
        public DateTime Created { get; set; }

        //Navigation Properties
        public OrderItem OrderItem { get; set; }
    }

    public class Station
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string StationParameter { get; set; }
        public ICollection<ProcessStep> ProcessSteps { get; set; }
    }

    public class ProcessFlow
    {
        public int ProcessFlowID { get; set; }
        public string ProcessFlowNumber { get; set; }
        public string ProcessFlowName { get; set; }

        //Navigation Properties
        public ICollection<Product> Products { get; set; }
        public ICollection<ProcessStep> ProcessSteps { get; set; }
    }

    public class ProcessStep
    {
        public int ProcessStepID { get; set; }
        public int StepNumber { get; set; }
        public string ProcessStepName { get; set; }
        public int ProcessFlowID { get; set; }
        public int StationID { get; set; }

        //Navigation Properties
        public ProcessFlow ProcessFlow { get; set; }
        public Station Station { get; set; }
    }

}
