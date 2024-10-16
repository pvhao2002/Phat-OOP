using System.Collections.Generic;
using Project.Model;

namespace Project.Service
{
    public interface IManager
    {
        bool Add(Device device);
        void Display();
        void Search(string name);
        bool Delete(string deviceId);
        bool Update(string id);

        Device Get(string deviceId);

        List<Device> GetList();

        void SortByName();
        void SortByPrice();
        void SortByStock();
        void StatisticByType();
    }
}