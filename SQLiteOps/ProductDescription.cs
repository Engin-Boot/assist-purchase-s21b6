    public class Dimensions
    {
        public double Height;
        public double Length;
        public double Width;
    }

    public class Description
    {
        //In cm (Validation required
        public readonly Dimensions ProductDimensions = new Dimensions();
        public string ProductId { get; set; }
        public string ModelNumber { get; set; }

        public string ProductName { get; set; }

        //In inches (Validation required 
        public double ScreenSize { get; set; }
        public double Weight { get; set; }
        public bool HasHandle { get; set; }
        public bool IsTouchScreen { get; set; }
        public bool IsCeCertified { get; set; }

        //Can be either LCD or LED, needs validation
        public string ScreenType { get; set; }
        public bool HasBattery { get; set; }
    }
