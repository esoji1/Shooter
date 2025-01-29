using UnityEngine;

public class SpawnWithProbability
{
    private Hilka _hilka;

    public SpawnWithProbability(Hilka hilka) =>
        _hilka = hilka;

    public void SpawnWithProbabilityInPercent(int spawnProbability, Transform transform)
    {
        int randomNumber = Random.Range(0, 100);

        if (spawnProbability > randomNumber)
            Object.Instantiate(_hilka, transform.position, Quaternion.identity, null);
    }
}
