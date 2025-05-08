namespace VideoGameCollection_WinForms.Repositories
{
    public class SqlRepository
    {
        public enum ServerLocation
        {
            Network,
            Local,
            NotSelected
        }

        public static ServerLocation server = ServerLocation.NotSelected;
    }
}
