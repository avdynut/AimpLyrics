namespace Aimp4.Api
{
    public struct AIMPVisualData
    {
        public float[] Peaks; // Size: 2
        public float[][] Spectrum; // Size: [3][AIMPVisual.MaxSpectrumLength];
        public float[][] WaveForm; // Size: [2][AIMPVisual.MaxWaveformLength];
        public int Reserved;

        public const int Size = sizeof(float) * (2 + 3 * AIMPVisual.MaxSpectrumLength + 2 * AIMPVisual.MaxWaveformLength) + sizeof(int);
    }
}