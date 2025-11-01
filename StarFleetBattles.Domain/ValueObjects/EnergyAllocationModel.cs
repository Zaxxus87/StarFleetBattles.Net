using System.ComponentModel.DataAnnotations;

namespace StarFleetBattles.Domain.ValueObjects
{
    public class EnergyAllocationModel
    {
        // Turn tracking
        public int TurnNumber { get; set; } = 1;

        // Basic Power Systems (rows 1-9)
        [Range(0, int.MaxValue)]
        public int WarpEnginePower { get; set; } = 30;

        [Range(0, int.MaxValue)]
        public int ImpulseEnginePower { get; set; } = 4;

        [Range(0, int.MaxValue)]
        public int ReactorPower { get; set; } = 4;

        [Range(0, int.MaxValue)]
        public int BatteryPowerAvailable { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int BatteryCapacityDischarged { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int LifeSupport { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ActiveFireControl { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ChargePhaser { get; set; } = 0;

        // Weapons and Equipment (row 10)
        [Range(0, int.MaxValue)]
        public int HeavyWeaponsA { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int HeavyWeaponsB { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int HeavyWeaponsC { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int HeavyWeaponsD { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SensorChannels { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int OtherEquipment { get; set; } = 0;

        // Additional equipment slots (E, F, G, H)
        [Range(0, int.MaxValue)]
        public int EquipmentSlotE { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int EquipmentSlotF { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int EquipmentSlotG { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int EquipmentSlotH { get; set; } = 0;

        // Shields and Reinforcement (rows 11-13)
        [Range(0, int.MaxValue)]
        public int ActivateShields { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int GeneralReinforcement { get; set; } = 0;

        // Specific Reinforcement (6 slots)
        [Range(0, int.MaxValue)]
        public int SpecificReinforcement1 { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SpecificReinforcement2 { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SpecificReinforcement3 { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SpecificReinforcement4 { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SpecificReinforcement5 { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int SpecificReinforcement6 { get; set; } = 0;

        // Movement (row 14)
        [Range(0, int.MaxValue)]
        public int HET { get; set; } = 0; // High Energy Turn

        [Range(0, int.MaxValue)]
        public int EmergencyBrakingEnergy { get; set; } = 0;

        // Additional Systems (rows 15-19)
        [Range(0, int.MaxValue)]
        public int DamageControl { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int RechargeBatteries { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int TractorBeam { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int Transporters { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ECM { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ECCM { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int Labs { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ChargeWildWeasel { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int CloakingDevice { get; set; } = 0;

        // Summary fields (rows 20-21)
        public int TotalPowerAvailable => WarpEnginePower + ImpulseEnginePower + ReactorPower;

        public int TotalPowerUsed => CalculateTotalPowerUsed();

        [Range(0, int.MaxValue)]
        public int BatteryPowerUsed { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int PhaserCapacitorsCharged { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int PhaserCapacitorsUsed { get; set; } = 0;

        // Notes
        public string MovementPlotNotes { get; set; } = string.Empty;

        // Helper method to calculate total power used
        private int CalculateTotalPowerUsed()
        {
            return LifeSupport + ActiveFireControl + ChargePhaser +
                   HeavyWeaponsA + HeavyWeaponsB + HeavyWeaponsC + HeavyWeaponsD + SensorChannels + OtherEquipment +
                   EquipmentSlotE + EquipmentSlotF + EquipmentSlotG + EquipmentSlotH +
                   ActivateShields + GeneralReinforcement +
                   SpecificReinforcement1 + SpecificReinforcement2 + SpecificReinforcement3 +
                   SpecificReinforcement4 + SpecificReinforcement5 + SpecificReinforcement6 +
                   HET + EmergencyBrakingEnergy + DamageControl + RechargeBatteries +
                   TractorBeam + Transporters + ECM + ECCM + Labs +
                   ChargeWildWeasel + CloakingDevice;
        }

        // Validation method
        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (TotalPowerUsed > TotalPowerAvailable + BatteryPowerAvailable)
            {
                errorMessage = "Total power used exceeds available power!";
                return false;
            }

            return true;
        }

        // Create a copy of this allocation
        public EnergyAllocationModel Clone()
        {
            return new EnergyAllocationModel
            {
                TurnNumber = this.TurnNumber,
                WarpEnginePower = this.WarpEnginePower,
                ImpulseEnginePower = this.ImpulseEnginePower,
                ReactorPower = this.ReactorPower,
                BatteryPowerAvailable = this.BatteryPowerAvailable,
                BatteryCapacityDischarged = this.BatteryCapacityDischarged,
                LifeSupport = this.LifeSupport,
                ActiveFireControl = this.ActiveFireControl,
                ChargePhaser = this.ChargePhaser,
                HeavyWeaponsA = this.HeavyWeaponsA,
                HeavyWeaponsB = this.HeavyWeaponsB,
                HeavyWeaponsC = this.HeavyWeaponsC,
                HeavyWeaponsD = this.HeavyWeaponsD,
                SensorChannels = this.SensorChannels,
                OtherEquipment = this.OtherEquipment,
                EquipmentSlotE = this.EquipmentSlotE,
                EquipmentSlotF = this.EquipmentSlotF,
                EquipmentSlotG = this.EquipmentSlotG,
                EquipmentSlotH = this.EquipmentSlotH,
                ActivateShields = this.ActivateShields,
                GeneralReinforcement = this.GeneralReinforcement,
                SpecificReinforcement1 = this.SpecificReinforcement1,
                SpecificReinforcement2 = this.SpecificReinforcement2,
                SpecificReinforcement3 = this.SpecificReinforcement3,
                SpecificReinforcement4 = this.SpecificReinforcement4,
                SpecificReinforcement5 = this.SpecificReinforcement5,
                SpecificReinforcement6 = this.SpecificReinforcement6,
                HET = this.HET,
                EmergencyBrakingEnergy = this.EmergencyBrakingEnergy,
                DamageControl = this.DamageControl,
                RechargeBatteries = this.RechargeBatteries,
                TractorBeam = this.TractorBeam,
                Transporters = this.Transporters,
                ECM = this.ECM,
                ECCM = this.ECCM,
                Labs = this.Labs,
                ChargeWildWeasel = this.ChargeWildWeasel,
                CloakingDevice = this.CloakingDevice,
                BatteryPowerUsed = this.BatteryPowerUsed,
                PhaserCapacitorsCharged = this.PhaserCapacitorsCharged,
                PhaserCapacitorsUsed = this.PhaserCapacitorsUsed,
                MovementPlotNotes = this.MovementPlotNotes
            };
        }
    }
}