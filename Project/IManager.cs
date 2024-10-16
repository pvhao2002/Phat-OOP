namespace Project
{
    public interface IManager
    {
        void Add(Device device);
        void Display();
        void Search(string name);
        void Delete(string deviceId);
        void Update(Device device);
    }
}