# swe1r-assets-unity

NOTE: broken as of 211750b: regression; re-export tests fail (binary files differ), will fix when I have the time

A Unity package (WIP, currently just a sample project) that allows you to import, modify and re-export assets of the game Star Wars Episode I: Racer.

Based on [swe1r-assets](https://github.com/akopetsch/swe1r-assets), it allows for bit-perfect re-exporting, meaning that if you import a block item (e.g., a model), make no changes in the Unity Editor, and export it again, the output binary data will be identical to the input data. Changing certain values will only alter the respective bytes in the output.

![Screenshot](screenshot.png)

## Community

Join the ``# modding`` channel of the discord server ['Star Wars Episode I: Racer'](https://discord.gg/xfvYpCma) for general discussions about hacking and modding of the game.
