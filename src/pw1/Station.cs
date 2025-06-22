using System;

namespace Station
{
    public class Station
    {
        private List<Platform> platforms;
        private List<Train> trains;

        public Station()
        {
            this.platforms = new List<Platform>();
            this.trains = new List<Train>();
        }

        public List<Platform> GetPlatforms()
        {
            return this.platforms;
        }
        public void AddPlatform(Platform platform)
        {
            this.platforms.Add(platform);
        }

        public List<Train> GetTrains()
        {
            return this.trains;
        }
        public void AddTrain(Train train)
        {
            this.trains.Add(train);
        }

        public void DisplayStatus()
        {
            Console.WriteLine("--- Trains ---");
            foreach (Train train in trains)
            {
                Console.WriteLine($"Train {train.GetId()} | Type: {train.GetTrainType()} | Status: {train.GetStatus()} | Arrival in: {train.GetArrivalTime()} min");
            }

            Console.WriteLine("\n--- Platforms ---");
            foreach (Platform platform in platforms)
            {
                if (platform.GetPlatStatus() == PlatformStatus.Occupied)
                {
                    Console.WriteLine($"Platform {platform.GetPlatId()} | Occupied by {platform.GetCurrentTrain().GetId()} | Remaining Docking Ticks: {platform.GetDockingTicksRemaining()}");
                }
                else
                {
                    Console.WriteLine($"Platform {platform.GetPlatId()} | Free");
                }
            }
        }

        public void AdvanceTick()
        {
            double hoursPerTick = 0.25;

            foreach (Train train in trains)
            {
                train.AdvanceTick(hoursPerTick);
            }

            foreach (Platform platform in platforms)
            {
                platform.AdvanceTick();
            }

            foreach (Train train in trains)
            {
                if (train.GetStatus() == TrainStatus.Waiting)
                {
                    bool docked = false;

                    foreach (Platform platform in platforms)
                    {
                        if (!docked && platform.GetPlatStatus() == PlatformStatus.Free)
                        {
                            platform.DockTrain(train);
                            docked = true;
                        }
                    }
                }
            }
        }

        public bool AllTrainsDocked()
        {
            foreach (Train train in trains)
            {
                if (train.GetStatus() != TrainStatus.Docked)
                {
                    return false;
                }
            }
            return true;
        }
    }
}