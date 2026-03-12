using System.Security.Claims;

namespace OOPS
{
    //•	Class should contain private variables:  productId, productName, unitPrice, qty.
    class Products
    {
        private int _productId;
        private string _productName;
        private double _unitPrice;
        private int _qty;

        //•	Constructor should allow productId as parameter
        public Products(int id)
        {
            _productId = id;
        }

        //•	ProductId – should be readonly property
        public int ProductId
        {
            get { return _productId; }
        }

        //•	 Create properties for all private variables.Property Names :   ProductId, ProductName, UnitPrice, Quantity

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        //•	ShowDetails()  method to display all the details along with total amount.*/
        public void ShowDetails()
        {
            double total= _unitPrice * _qty;
            Console.WriteLine("ProductId: " + _productId);
            Console.WriteLine("ProductName: " + _productName);
            Console.WriteLine("Unit Price: " + _unitPrice);
            Console.WriteLine("Quantity : " + _qty);
            Console.WriteLine("Total Amount : " + total); 
        }
    }
    internal class Program
    {   

        static void Main(string[] args)
        {
            Products products = new Products(101);
            products.ProductName = "Laptop";
            products.UnitPrice = 80000;
            products.Qty = 2;

            products.ShowDetails();

            Console.ReadLine();
        }
    }
}



