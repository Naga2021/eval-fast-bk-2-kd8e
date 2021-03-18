using System;

namespace FortCodeExercises.Exercise1
{
    public class Machine
    {
        public string machineName = "";
        public int type = 0;

        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(this.machineName) ? GetMachineName(this.type) : string.Empty;
            }
        }

        public string Description
        {
            get
            {
                bool hasMaxSpeed = HasMaxSpeed(this.type);
                return string.Format(" {0} {1} [{2}]. ", this.Color, this.Name, this.GetMaxSpeed(this.type, hasMaxSpeed));
            }
        }

        private bool HasMaxSpeed(int type)
        {
            bool hasMaxSpeed = true;
            switch (type)
            {
                case 1:
                case 2:
                    hasMaxSpeed = true;
                    break;
                case 3:
                case 4:
                    hasMaxSpeed = false;
                    break;

            }
            return hasMaxSpeed;
        }
        public string Color
        {
            get
            {
                return GetColor(this.type);
            }
        }
        public string trimColor
        {
            get
            {
                string trimColor = string.Empty;
                string baseColor = GetColor(this.type);
                bool isDark = this.IsDark(baseColor);

                if (this.type == 1 && isDark) trimColor = "black";
                else if (this.type == 1 && !isDark) trimColor = "white";
                else if (this.type == 2 && isDark) trimColor = "gold";
                else if (this.type == 3 && isDark) trimColor = "silver";
                return trimColor;
            }
        }

        public bool IsDark(string color)
        {
            bool isDark = true;
            switch (color)
            {
                case "red":
                case "green":
                case "black":
                case "crimson":
                    isDark = true;
                    break;
                case "yellow":
                case "white":
                case "beige":
                case "babyblue":
                    isDark = false;
                    break;

            }
            return isDark;
        }

        public int GetMaxSpeed(int machineType, bool noMax = false)
        {
            int max = 70;
            if (machineType == 1 && noMax == false) max = 70;
            else if (noMax == false && machineType == 2) max = 60;
            else if (machineType == 0 && noMax == true) max = 80;
            else if ((machineType == 2 || machineType == 4) && noMax == true) max = 90;
            else if (machineType == 1 && noMax == true) max = 75;
            return max;
        }

        private string GetMachineName(int type)
        {
            return Enum.IsDefined(typeof(MachineName), type) ?
                   Enum.GetName(typeof(MachineName), type).ToString() :
                    string.Empty;
        }

        private string GetColor(int type)
        {
            return Enum.IsDefined(typeof(Colors), type) ?
                    Enum.GetName(typeof(Colors), type).ToString() :
                     "white";
        }

        private enum Colors
        {
            red,
            blue,
            green,
            yellow,
            brown
        }
        private enum MachineName
        {
            bulldozer,
            crane,
            tractor,
            truck,
            car
        }

    }
}