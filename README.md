# crypto-sample-api
This is a sample custom crypt service. So you DO NOT have to use for prod.

### Sample
- Input strings: ```pass```
- Results ```0000f03003610000a04703470000ae4c029700005cfd0323```

### Logic
1. Get ASCII code each chars.
    - `p`,`a`,`s`,`s`
    - `112`,`97`,`115`,`115`
1. Get first prime between 0 and 9 (random).
    - `3` for `p(112)`
    - `3` for `a(97)`
    - `2` for `s(115)`
    - `3` for `s(115)`
1. Get second prime between 10 and 99 (random).
    - `61` for `p(112)`
    - `47` for `a(97)`
    - `97` for `s(115)`
    - `23` for `s(115)`
1. Calcualte original logic.
    - `3 ^ 2 * 61 * 112 = 61488`
    - `3 ^ 2 * 47 * 97 = 41031`
    - `2 ^ 2 * 97 * 115 = 44620`
    - `3 ^ 2 * 23 * 115 = 23805`
1. Convert to HEX.
    - `F030`
    - `A047`
    - `AE4C`
    - `5CFD`
1. Pad with zeros up to 8 characters.
    - `0000F030`
    - `0000A047`
    - `0000AE4C`
    - `00005CFD`
1. Append first prime and second prime.
    - `0000F0300361`
    - `0000A0470347`
    - `0000AE4C0297`
    - `00005CFD0323`
1. Join all characters.
    - `0000F0300361` + `0000A0470347` + `0000AE4C0297` + `00005CFD0323` -> `0000F03003610000A04703470000AE4C029700005CFD0323`