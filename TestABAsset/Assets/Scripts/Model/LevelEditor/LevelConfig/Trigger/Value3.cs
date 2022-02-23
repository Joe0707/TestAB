namespace Levels.Trigger
{
    public class Value3
    {
        public float x = 0;
        public float y = 0;
        public float z = 0;
        public Value3()
        {

        }

        public Value3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Value3 Clone()
        {
            var result = new Value3();
            result.x = this.x;
            result.y = this.y;
            result.z = this.z;
            return result;
        }
    }

}