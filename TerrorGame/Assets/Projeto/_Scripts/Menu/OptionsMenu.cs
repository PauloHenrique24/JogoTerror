using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Sliders")]
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider sensitivitySlider;

    [Header("Porcentagens")]
    public TextMeshProUGUI soundText;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sensitivityText;

    [Header("Dropdown")]
    public TMP_Dropdown graphicsDropdown;

    [Header("Audio")]
    public AudioMixer audioMixer; // Certifique-se de ter os parâmetros "Musica" e "Sound" no mixer

    const string MIXER_MUSIC = "Musica";
    const string MIXER_SOUND = "Sound";

    void Start()
    {
        // Carregar valores salvos ou definir padrões
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
        int savedGraphics = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());

        // Aplicar valores nos sliders
        soundSlider.value = savedSFX;
        musicSlider.value = savedMusic;
        sensitivitySlider.value = savedSensitivity;
        graphicsDropdown.value = savedGraphics;

        // Atualizar textos
        UpdateSliderText(soundText, savedSFX, soundSlider);
        UpdateSliderText(musicText, savedMusic, musicSlider);
        UpdateSliderText(sensitivityText, savedSensitivity, sensitivitySlider);

        ApplySettings();

        // Listeners
        soundSlider.onValueChanged.AddListener(SetSoundVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
        graphicsDropdown.onValueChanged.AddListener(SetGraphicsQuality);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_SOUND, Mathf.Log10(Mathf.Clamp(volume, 0.001f, 1f)) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        UpdateSliderText(soundText, volume,soundSlider);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(Mathf.Clamp(volume, 0.001f, 1f)) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        UpdateSliderText(musicText, volume, musicSlider);
    }

    public void SetSensitivity(float sensitivity)
    {
        GameController.MouseSensitivity = sensitivity;
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        UpdateSliderText(sensitivityText, sensitivity, sensitivitySlider);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex,true);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
    }

    public void ApplySettings()
    {
        SetSoundVolume(soundSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSensitivity(sensitivitySlider.value);
        SetGraphicsQuality(graphicsDropdown.value);
    }

    private void UpdateSliderText(TextMeshProUGUI textComponent, float value,Slider slider)
    {
        float normalized = Mathf.InverseLerp(slider.minValue, slider.maxValue, value); // Converte para [0, 1]
        int percent = Mathf.RoundToInt(normalized * 100f);
        textComponent.text = percent + "%";
    }
}
