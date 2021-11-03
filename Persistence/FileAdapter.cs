using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public class FileAdapter : IFileAdapter, IStatisticsModel
    {
        private readonly FileContext Context;

        public FileAdapter()
        {
            Context = new FileContext();
        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            var adults = new List<Adult>(Context.Adults);
            return adults;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            var id = Context.Adults.Max(max => max.Id) + 1;
            adult.Id = id;
            Context.Adults.Add(adult);
            Context.SaveChanges();
            return adult;
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            return Context.Adults.First(a => a.Id == id);
        }

        public async Task RemoveAdultAsync(int id)
        {
            var delete = Context.Adults.First(a => a.Id == id);
            Context.Adults.Remove(delete);
            Context.SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            var ad = Context.Adults.First(a => a.Id == adult.Id);
            ad.FirstName = adult.FirstName;
            ad.LastName = adult.LastName;
            ad.Age = adult.Age;
            ad.Height = adult.Height;
            ad.Weight = adult.Weight;
            ad.JobTitle = adult.JobTitle;
            ad.EyeColor = adult.EyeColor;
            ad.Sex = adult.Sex;
            ad.HairColor = adult.HairColor;
            ad.Id = adult.Id;
            Context.SaveChanges();
            return ad;
        }

        public async Task<int> GetAdultAgeGroupAsync(int minimum, int maximum)
        {
            var count = 0;
            foreach (var a in Context.Adults)
                if (a.Age >= minimum && a.Age <= maximum)
                    count++;
            return count;
        }

        public async Task<double> GetEyeColorPercentageAsync(string color)
        {
            var count = 0;
            foreach (var a in Context.Adults)
                if (a.EyeColor.Equals(color))
                    count++;
            return (double) count / Context.Adults.Count;
        }
    }
}