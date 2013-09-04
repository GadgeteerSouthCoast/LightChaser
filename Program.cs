
using GT = Gadgeteer;

using Motor = Gadgeteer.Modules.GHIElectronics.MotorControllerL298.Motor;

namespace GadgeteerApp1
{
    public partial class Program
    {
        void ProgramStarted()
        {
            var timer = new GT.Timer(50);
            timer.Tick += new GT.Timer.TickEventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(GT.Timer timer)
        {
            var lightLevel1 = lightSensor.ReadLightSensorPercentage();
            var lightLevel2 = lightSensor1.ReadLightSensorPercentage();

            if (lightLevel1 - lightLevel2 > 20)
            {
                TurnLeft();
            }
            else if (lightLevel2 - lightLevel1 > 20)
            {
                TurnRight();
            }
            else
            {
                Stop();
            }
        }

        private void Stop()
        {
            DriveMotor(Motor.Motor1, 0);
            DriveMotor(Motor.Motor2, 0);
        }

        private void TurnRight()
        {
            DriveMotor(Motor.Motor1, 50);
            DriveMotor(Motor.Motor2, -50);
        }

        private void TurnLeft()
        {
            DriveMotor(Motor.Motor1, -50);
            DriveMotor(Motor.Motor2, 50);
        }

        private void DriveMotors(int motor1Speed, int motor2Speed)
        {
            DriveMotor(Motor.Motor1, motor1Speed);
            DriveMotor(Motor.Motor2, motor2Speed);
        }

        private void DriveMotor(Motor motor, int speed)
        {
            motorControllerL298.MoveMotor(motor, speed);
        }
    }
}
