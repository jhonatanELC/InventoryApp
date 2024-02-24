namespace InventoryApp.Helpers
{
    internal class GroupConverter
    {
        // Mapping between Spanish and English enum values
        private static readonly Dictionary<string, Group> SpanishToEnglishMap = new Dictionary<string, Group>
        {
            { "caja", Group.Gearbox },
            { "corona", Group.RearAxle},
        };

        // Convert Spanish input to English enum value
        public static bool TryConvertFromSpanish(string spanishInput, out Group englishValue)
        {
            return SpanishToEnglishMap.TryGetValue(spanishInput.ToLower(), out  englishValue);
        }
    }
}
