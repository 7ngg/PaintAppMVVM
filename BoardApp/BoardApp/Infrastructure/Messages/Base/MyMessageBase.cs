namespace BoardApp.Infrastructure.Messages.Base
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
