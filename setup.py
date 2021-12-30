from cx_Freeze import setup, Executable
#import cx_Freeze

'''
executables = [cx_Freeze.Executable("car_game.py")]

cx_Freeze.setup(
    name = "A Bit Racey",
    options = {"Build_exe": {"packages":["pygame"],
                             "include_files":["car_1.png"]}},
    executables = executables
    )
'''

include_files = ['car_1.png']


setup(name = "A Bit Racey" ,
      version = "0.1" ,
      description = "" ,
      options = {"Build_exe": {"packages":["pygame"],"include_files":include_files}},
      executables = [Executable("car_game.py")])
