using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class PlService
    {
        public BL.BL Bl { get; set; } = new();

        public void Add(int id, Types type, double range, double sight)
        {
            try
            {
                Bl.Add(id, (BL.Types)type, range, sight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Remove(int id, Types type)
        {
            try
            {
                Bl.Remove(id, (BL.Types)type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public List<MeansOfObservation> GetList()
        {
            return ConvertAll(Bl.GetList());
        }

        public List<MeansOfObservation> GetItemsFromType(Types type)
        {
            return ConvertAll(Bl.GetItemFromType((BL.Types)type));
        }

        public List<MeansOfObservation> GetSortedList()
        {
            return ConvertAll(Bl.GetSortedList());
        }

        public MeansOfObservation GetLargestRange(double minSight)
        {
            try
            {
                return Convert(Bl.GetLargestRange(minSight));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;   
        }

        public MeansOfObservation Convert(BL.MeansOfObservation item)
        {
            return new MeansOfObservation(item.Id, (Types)item.Type, item.Range, item.Sight);
        }

        public List<MeansOfObservation> ConvertAll(List<BL.MeansOfObservation> list)
        {
            List<MeansOfObservation> result = new();

            foreach (var item in list)
            {
                result.Add(Convert(item));
            }

            return result;
        }

        public void PrintList(List<MeansOfObservation> list)
        {
            foreach (var item in list)
            {
                PrintItem(item);
            }
        }

        public void PrintItem(MeansOfObservation item)
        {
            if (item == null) return;
            Console.WriteLine("***");
            Console.WriteLine($"item of type {item.Type} number #{item.Id}:");
            Console.WriteLine($"Sight: {item.Sight}");
            Console.WriteLine($"Range: {item.Range}");
            Console.WriteLine("***");
        }
    }
}   

