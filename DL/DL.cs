using System;
using System.Collections.Generic;

namespace DL
{
    public class DL
    {
        List<MeansOfObservation> observations { get; set; } = new();
        

        public void Add(int id, Types type, double range, double sight) 
        {
            MeansOfObservation item = observations.Find(item => item.Id == id && item.Type == type);

            if (item != default(MeansOfObservation))
                throw new Exception($"Item From Type {type} and with ID {id} already exist.");

            MeansOfObservation newItem = new MeansOfObservation(id, type, range, sight);
            observations.Add(newItem);
        }

        public void Remove(int id, Types type)
        {
            MeansOfObservation item = observations.Find(item => item.Id == id && item.Type == type);

            if (item == default(MeansOfObservation))
                throw new Exception("Item Not Found");

            observations.Remove(item);
        }

        public List<MeansOfObservation> GetList()
        {
            return observations;
        }


    }
}
