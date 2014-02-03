using System;

/*
 * Copyright (C) 2006 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace NewColorEveryReboot
{
    class ColorConvert
    {
        public static uint HSBtoColor(float h, float s, float b) {        
            float red = 0.0f;
            float green = 0.0f;
            float blue = 0.0f;
        
            float hf = (h - (int) h) * 6.0f;
            int ihf = (int) hf;
            float f = hf - ihf;
            float pv = b * (1.0f - s);
            float qv = b * (1.0f - s * f);
            float tv = b * (1.0f - s * (1.0f - f));

            switch (ihf) {
                case 0:         // Red is the dominant color
                    red = b;
                    green = tv;
                    blue = pv;
                    break;
                case 1:         // Green is the dominant color
                    red = qv;
                    green = b;
                    blue = pv;
                    break;
                case 2:
                    red = pv;
                    green = b;
                    blue = tv;
                    break;
                case 3:         // Blue is the dominant color
                    red = pv;
                    green = qv;
                    blue = b;
                    break;
                case 4:
                    red = tv;
                    green = pv;
                    blue = b;
                    break;
                case 5:         // Red is the dominant color
                    red = b;
                    green = pv;
                    blue = qv;
                    break;
            }

            return ((uint) 0xFF000000) | (((uint) (red * 255.0f)) << 16) |
                    (((uint) (green * 255.0f)) << 8) | ((uint) (blue * 255.0f));
        }

    }
}
