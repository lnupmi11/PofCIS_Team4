namespace TaxiServices
{
    public static class OrderService
    {
        public static double CountPrice(Order order)
        {
            double price;

            switch (order.CarType)
            {
                case CarType.Econom:
                {
                    price = 100 + 10 * order.Start.Length;
                }
                break;
                case CarType.Wagon:
                {
                    price = 200 + 11 * order.Start.Length;
                }
                break;
                case CarType.Comfort:
                {
                    price = 300 + 12 * order.Start.Length;
                }
                break;
                case CarType.Business:
                {
                    price = 400 + 13 * order.Start.Length;
                }
                break;
                default:
                {
                    price = 0.0;
                }
                break;
            }

            return price;
        }
        
    }
}
