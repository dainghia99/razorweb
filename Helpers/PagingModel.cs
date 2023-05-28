namespace razorweb.Helpers {
    public class PagingModel {
        public int curentPageSize { get; set; }
        public int countPageSize { get; set; }
        public Func<int?, string> generateUrl { get; set; }

    }
}