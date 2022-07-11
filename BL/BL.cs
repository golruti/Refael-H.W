using DL;
using System;
using System.Collections.Generic;

namespace BL
{
    public class BL
    {
        public DL.DL Dl { get; set; } = new();

        public void Add(int id, Types type, double range, double sight)
        {
            try 
            {
                Dl.Add(id, (DL.Types)type, range, sight);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void Remove(int id, Types type)
        {
            try
            {
                Dl.Remove(id, (DL.Types)type);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<MeansOfObservation> GetList()
        {
            return ConvertAll(Dl.GetList());
        }

        public List<MeansOfObservation> GetItemFromType(Types type)
        {
            return ConvertAll(Dl.GetList()).FindAll(item => item.Type == type);
        }

        public List<MeansOfObservation> GetSortedList()
        {
            List<MeansOfObservation> res = ConvertAll(Dl.GetList());
            res.Sort();
            return res;
            
        }

        public MeansOfObservation GetLargestRange(double minSight)
        {
            var list = Dl.GetList();

            if(list == null)
                throw new Exception("The list is empty.");

            var BLlist = ConvertAll(list).FindAll(item => item.Sight >= minSight);

            if (BLlist[0] == null)
                throw new Exception("No matching item.");

            MeansOfObservation res = BLlist[0];


            foreach (var item in BLlist)
            {
                if (item.Range > res.Range)
                    res = item;
            }

            return res;
        }

        public MeansOfObservation Convert(DL.MeansOfObservation item)
        {
            return new MeansOfObservation(item.Id, (Types)item.Type, item.Range, item.Sight);
        }

        public List<MeansOfObservation> ConvertAll(List<DL.MeansOfObservation> list)
        {
            List<MeansOfObservation> result = new();

            foreach (var item in list)
            {
                result.Add(Convert(item));
            }

            return result;
        }
    }
}
