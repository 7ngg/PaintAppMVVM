namespace BoardApp.Models
{
    public class WindowPropertyModel : IData
    {
        public int Windth { get; set; }
        public int Height { get; set; }

        public WindowPropertyModel(int windth, int height)
        {
            Windth = windth;
            Height = height;
        }
    }
}
