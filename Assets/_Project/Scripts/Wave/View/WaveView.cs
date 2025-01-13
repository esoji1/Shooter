using TMPro;

public class WaveView
{
    private TextMeshProUGUI _waveText;
    private int _totalWaves;

    public WaveView(TextMeshProUGUI waveText, int totalWaves)
    {
        _waveText = waveText;
        _totalWaves = totalWaves;
    }

    public void Show(int currentWave) => _waveText.text = $"{currentWave + 1}/{_totalWaves}";
}
