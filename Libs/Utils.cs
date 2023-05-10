namespace Libs {
    public static class Utils {
        public static string GetInputFilename() {
            string workingDir = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            return $"{workingDir}\\input.txt";
        }
    }

    public class OldNew<T> {
        private T currentValue;
        private T newValue;

        public OldNew(T initialValue) {
            currentValue = initialValue;
            newValue = initialValue;
        }

        public void Apply() {
            currentValue = newValue;
        }

        public T Value {
            get {
                return currentValue;
            }
            set {
                newValue = value;
            }
        }

        public override string ToString() {
            return $"{currentValue},{newValue}";
        }
    }
}
