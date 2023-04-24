using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_NoiseFilterFactory
{
    public static S_INoiseFilter CreateNosieFilter(S_NoiseSettings settings)
    {
        switch(settings.filterType)
        {
            case S_NoiseSettings.FilterType.SIMPLE:
                return new S_SimpleNoiseFilter(settings.simpleNoiseSettings);
            case S_NoiseSettings.FilterType.RIGID:
                return new S_RigidNoiseFilter(settings.rigidNoiseSettings);
        }

        return null;
    }
}
