namespace Libs {
    public static class Utils {
        public static string GetInputFilename() {
            string workingDir = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            return $"{workingDir}\\input.txt";
        }
    }
}
