using System;

namespace Station
{
    public enum PlatformStatus
    {
        Free,
        Occupied
    }
    public class Platform
    {
        private string platId;
        private PlatformStatus status;
        private Train currentTrain;
        private int dockingTime = 2;
        private int dockingTicksRemaining;


        public Platform(string platId)
        {
            this.platId = platId;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTicksRemaining = 0;
        }

        public string GetPlatId()
        {
            return this.platId;
        }

        public void SetPlatId(string id)
        {
            this.platId = id;
        }

        public PlatformStatus GetPlatStatus()
        {
            return this.status;
        }

        public void SetPlatStatus(PlatformStatus stat)
        {
            this.status = stat;
        }

        public Train GetCurrentTrain()
        {
            return this.currentTrain;
        }

        public void SetCurrentTrain(Train t)
        {
            this.currentTrain = t;
        }

        public int GetDockingTime()
        {
            return this.dockingTime;
        }

        public void SetDockingTime(int time)
        {
            this.dockingTime = time;
        }

        public int GetDockingTicksRemaining()
        {
            return this.dockingTicksRemaining;
        }
        public void SetDockingTicksRemaining(int ticks)
        {
            this.dockingTicksRemaining = ticks;
        }

        public bool IsAvailable()
        {
            return this.status == PlatformStatus.Free;
        }


        public void DockTrain(Train train)
        {
            this.currentTrain = train;
            this.status = PlatformStatus.Occupied;
            this.dockingTicksRemaining = this.dockingTime;
            train.SetStatus(TrainStatus.Docking);
        }

        public void AdvanceTick()
        {
            if (this.status == PlatformStatus.Occupied && this.dockingTicksRemaining > 0)
            {
                this.dockingTicksRemaining--;
                if (this.dockingTicksRemaining == 0)
                {
                    this.currentTrain.SetStatus(TrainStatus.Docked);
                    this.currentTrain = null;
                    this.status = PlatformStatus.Free;
                }
            }
        }
    }
}