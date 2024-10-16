namespace Project
{
    public interface IManager
    {
        bool Add(Device device);
        void Display();
        void Search(string name);
        bool Delete(string deviceId);
        bool Update(Device device);

        Device Get(string deviceId);
    }
}