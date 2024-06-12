//from: https://medium.com/xp-inc/dica-r%C3%A1pida-net-env-76b0c66dac4

public static class EnvConfig{
    public static void Load(string path){
        if (!File.Exists(path))
            return;

        foreach (var line in File.ReadAllLines(path)){
            var part = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (part.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(part[0], part[1]);
        }
    }
}