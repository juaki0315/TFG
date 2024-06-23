using UnityEngine;

public class CrossFadeMusic : MonoBehaviour
{
    public AudioSource audioSourceA;    // Primera instancia de AudioSource
    public AudioSource audioSourceB;    // Segunda instancia de AudioSource
    public float crossFadeDuration = 2f; // Duración del cross fade en segundos

    private bool isCrossFading = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // Inicia la reproducción de la primera instancia de AudioSource
        audioSourceA.Play();
    }

    void Update()
    {
        // Si estamos en el proceso de cross fade
        if (isCrossFading)
        {
            fadeTimer += Time.deltaTime;

            // Calcula el valor del cross fade entre 0 y 1
            float normalizedTime = fadeTimer / crossFadeDuration;

            // Ajusta el volumen de ambas instancias de AudioSource para el cross fade
            audioSourceA.volume = Mathf.Lerp(1f, 0f, normalizedTime);
            audioSourceB.volume = Mathf.Lerp(0f, 1f, normalizedTime);

            // Si hemos completado el cross fade
            if (fadeTimer >= crossFadeDuration)
            {
                // Detén la instancia A y ajusta el volumen al final
                audioSourceA.Stop();
                audioSourceA.volume = 1f;

                // Reinicia la instancia B para reproducirla en bucle
                audioSourceB.Play();
                audioSourceB.volume = 1f;

                // Restablece las variables de control
                isCrossFading = false;
                fadeTimer = 0f;
            }
        }
    }

    public void StartCrossFade()
    {
        // No inicies un cross fade si ya estamos en proceso
        if (isCrossFading)
            return;

        // Inicia el cross fade entre las dos instancias de AudioSource
        isCrossFading = true;
        fadeTimer = 0f;

        // Reinicia la instancia B para reproducirla en bucle
        audioSourceB.Play();
        audioSourceB.volume = 0f; // Comienza en volumen cero para fundirse gradualmente
    }
}
