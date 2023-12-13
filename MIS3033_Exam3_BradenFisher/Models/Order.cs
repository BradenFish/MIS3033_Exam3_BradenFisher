namespace MIS3033_Exam3_BradenFisher.Models
{
    public class Order
    {
        public string Id { get; set; }
        public double Subtotal { get; set; }
        public double Tip { get; set; }
        public double TipRatio { get; set; }
        public string TipRatioLevel { get; set; }

        public Order() { }

        public double CalTipRatio()
        {
            TipRatio = Tip / Subtotal;
            return TipRatio;
        }

        public string CalTipRatioLevel()
        {
            if (TipRatio < 0.10)
            {
                TipRatioLevel = "Level 1";
            }
            else if (TipRatio < 0.20)
            {
                TipRatioLevel = "Level 2";
            }
            else
            {
                TipRatioLevel = "Level 3";
            }

            return TipRatioLevel;
        }
    }
}
