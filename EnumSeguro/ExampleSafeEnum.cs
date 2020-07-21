namespace EnumSeguro
{
    public class ExampleSafeEnum : BaseSafeEnum<ExampleSafeEnum>
    {
        public ExampleSafeEnum(object id, string description) : base(id, description)
        {
        }

        public static ExampleSafeEnum Exemple1 = new ExampleSafeEnum(1, "TEST 1");
        public static ExampleSafeEnum Exemple2 = new ExampleSafeEnum(2, "TEST 2");
    }
}