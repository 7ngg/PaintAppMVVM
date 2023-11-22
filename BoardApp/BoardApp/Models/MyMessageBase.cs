namespace BoardApp.Models
{
    public class MyMessageBase<TData>
    {
        public TData UserData { get; set; }

        public MyMessageBase(TData userData)
        {
            UserData = userData;
        }
    }
}
