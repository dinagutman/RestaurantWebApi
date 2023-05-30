using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class WorkingHoursRepository : IWorkingHoursRepository
    {
        RestaurantObject context = new RestaurantObject();
        public WorkingHoursRepository(RestaurantObject context)
        {
            this.context = context;
        }
        public List<WorkingHours> GetAllWorkingHours()
        {
      
            return context.WorkingHours.ToList();
        }
        public int AddWorkingHours(WorkingHours workingHours)
        {
            var isExists = context.WorkingHours.Any(w => w.EmployeeCode == workingHours.EmployeeCode && w.EnterTime == workingHours.EnterTime);
            if (!isExists)
            {
                var result = context.WorkingHours.Add(workingHours);
                context.SaveChanges();
                return result.Entity.WorkingHoursCode;
            }
            return -1;
        }
        public List<WorkingHours> GetWorkingHoursByEmployeeCodeAndDates(DateTime from, DateTime until, string search = " ")
        {
            if (search == null)
            {
                return context.WorkingHours.Where(w => w.WorkingDate >= from && w.WorkingDate <= until).ToList();
            }
            else
            {
                return context.WorkingHours.Where(w => w.EmployeeFirstName.ToUpper().StartsWith(search.ToUpper()) && w.WorkingDate >= from && w.WorkingDate <= until).ToList();
            }
        }
        public void UpdateExitTimeAndTotalHours(int workingHoursCode)
        {
            string result = "";
            float cameIn, goOut;
            WorkingHours query = null;
            query = context.WorkingHours.Where(w => w.WorkingHoursCode == workingHoursCode && w.WorkingDate == DateTime.Today && w.ExitTime == "").First();
            if (query != null)
            {
                query.ExitTime = DateTime.Now.ToString("HH:mm:ss");
                string[] enterValues = query.EnterTime.Split(':');
                string[] exitValues = query.ExitTime.Split(':');
                if (enterValues[0] == "00")
                {
                    cameIn = 24 * 60 + int.Parse(enterValues[1]);
                }
                else
                {
                    cameIn = int.Parse(enterValues[0]) * 60 + int.Parse(enterValues[1]);
                }
                if (exitValues[0] == "00")
                {
                    goOut = 24 * 60 + int.Parse(exitValues[1]);
                }
                else
                {
                    goOut = int.Parse(exitValues[0]) * 60 + int.Parse(exitValues[1]);
                }
                if ((goOut - cameIn) > 60)
                {
                    if ((goOut - cameIn) / 60 < 10)
                    {
                        result = "0" + ((goOut - cameIn) / 60).ToString() + ":";
                    }
                    else
                    {
                        result = ((goOut - cameIn) / 60).ToString() + ":";
                    }
                    result += ((goOut - cameIn) % 60) < 10 ? "0" + ((goOut - cameIn) % 60).ToString() : ((goOut - cameIn) % 60).ToString();
                    if (((goOut - cameIn) % 60) == 0)
                    {
                        result += "0";
                    }
                }
                if ((goOut - cameIn) < 60)
                {
                    result += "00:";
                    if ((goOut - cameIn) % 60 < 10)
                    {
                        result += "0" + (goOut - cameIn).ToString();
                    }
                    else
                    {
                        result += (goOut - cameIn).ToString();
                    }
                }
                query.TotalHoursForDay = result;
                context.SaveChanges();
            }
        }
    }
}

