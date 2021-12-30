import pygame
import time
import random


display_width = 800
display_height = 600

black = (0,0,0) #black color
white = (255,255,255) #white color
red = (200,0,0) #dark red color
green = (0,200,0) #dark green color

block_color = (53,115,255)

bright_red = (255,0,0) #red color
bright_green = (0,255,0) #green color


car_width = 48

pygame.init()

#adding sound effect
crash_sound = pygame.mixer.Sound("Crash.wav")

#adding music
pygame.mixer.music.load("music.wav")


gameDisplay = pygame.display.set_mode((display_width,display_height))
pygame.display.set_caption('A bit Racey')
clock = pygame.time.Clock()

car_img = pygame.image.load('car_1.png')

#set game icon
pygame.display.set_icon(car_img)

pause = False
#crash = True

def things_dodged(count):
    font = pygame.font.SysFont('comicsansms', 25)
    text = font.render('Dodged: ' +str(count), True, black)
    gameDisplay.blit(text, (0,0))

def things(thingx, thingy, thingw, thingh, color):
    pygame.draw.rect(gameDisplay, color, [thingx, thingy, thingw, thingh])

def Car(x,y):
    gameDisplay.blit(car_img, (x,y))

def text_objects(text, font):
    textSurface = font.render(text, True, black)
    return textSurface, textSurface.get_rect()

def quit_game():
    pygame.quit()
    quit()

def unpause():
    global pause
    pygame.mixer.music.unpause()
    pause = False

def paused():

    #music to pause
    pygame.mixer.music.pause()
    
    largeText = pygame.font.SysFont('comicsansms', 115)
    TextSurf, TextRect = text_objects('Paused', largeText)
    TextRect.center = ((display_width/2), (display_height/2))
    gameDisplay.blit(TextSurf, TextRect)
    
    while pause:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()

        #gameDisplay.fill(white)
        

        #adding buttons to the intro 'Play' and 'Quit'
        #button(msg, x, y, w, h, Inct_col, act_col)
        button('Continue', 150, 450, 100, 50, green, bright_green, unpause)
        button('QUIT', 550, 450, 100, 50, red, bright_red, quit_game)
        
        pygame.display.update()
        clock.tick(15)

def message_display(text):
    largeText = pygame.font.SysFont('comicsansms', 115)
    TextSurf, TextRect = text_objects(text, largeText)
    TextRect.center = ((display_width/2), (display_height/2))
    gameDisplay.blit(TextSurf, TextRect)

    pygame.display.update()

    time.sleep(2)

    game_loop()

def crash():

    pygame.mixer.music.stop()
    pygame.mixer.Sound.play(crash_sound)
    
    largeText = pygame.font.SysFont('comicsansms', 115)
    TextSurf, TextRect = text_objects('You Crashed!', largeText)
    TextRect.center = ((display_width/2), (display_height/2))
    gameDisplay.blit(TextSurf, TextRect)
    
    while True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()

        #gameDisplay.fill(white)
        

        #adding buttons to the intro 'Play' and 'Quit'
        #button(msg, x, y, w, h, Inct_col, act_col)
        button('Play Again', 150, 450, 100, 50, green, bright_green, game_loop)
        button('QUIT', 550, 450, 100, 50, red, bright_red, quit_game)
        
        pygame.display.update()
        clock.tick(15)

def button(msg, x, y, w, h, Inct_col, act_col, action = None):
    #it gets mouse position or co-ordinates on the screen 
    mouse = pygame.mouse.get_pos() 

    click = pygame.mouse.get_pressed()
    
    #button interaction for Button method
    if x+w > mouse[0] > x and y+h > mouse[1] > y:
        pygame.draw.rect(gameDisplay, act_col, (x, y, w, h))
        if click[0] == 1 and action != None:
            action()
##            if action == 'Play':  press alt + 3 for fast commenting
##                game_loop()
##            elif action == 'Quit':
##                pygame.quit()
##                quit()
            
    else:
        pygame.draw.rect(gameDisplay, Inct_col, (x, y, w, h))

    #adding text on button method
    smallText = pygame.font.SysFont('comicsansms', 20)
    TextSurf, TextRect = text_objects(msg, smallText)
    TextRect.center = ((x+(w/2)), (y+(h/2)))
    gameDisplay.blit(TextSurf, TextRect)

def game_intro():
    intro = True

    while intro:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()

        gameDisplay.fill(white)
        largeText = pygame.font.SysFont('comicsansms', 115)
        TextSurf, TextRect = text_objects('A Bit Racey', largeText)
        TextRect.center = ((display_width/2), (display_height/2))
        gameDisplay.blit(TextSurf, TextRect)

        #adding buttons to the intro 'Play' and 'Quit'
        #button(msg, x, y, w, h, Inct_col, act_col)
        button('GO!', 150, 450, 100, 50, green, bright_green, game_loop)
        button('QUIT', 550, 450, 100, 50, red, bright_red, quit_game)
        
        pygame.display.update()
        clock.tick(15)

def game_loop():
    global pause

    #plays music infinitly
    pygame.mixer.music.play(-1)
    
    x = (display_width * 0.45)
    y = (display_height * 0.8)

    x_change = 0

    thing_startx = random.randrange(0, display_width)
    thing_starty = -600
    thing_speed = 4
    thing_width = 100
    thing_height = 100

    dodged = 0

    gameExit = False

    while not gameExit:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()

            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_LEFT:
                    x_change = -5
                if event.key == pygame.K_RIGHT:
                    x_change = 5
                if event.key == pygame.K_p:
                    pause = True
                    paused()

            if event.type == pygame.KEYUP:
                if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
                    x_change = 0

        x += x_change  

        gameDisplay.fill(white)

        #things(thingx, thingy, thingw, thingh, color)
        things(thing_startx, thing_starty, thing_width, thing_height, block_color)
        thing_starty += thing_speed
        
        Car(x,y)
        things_dodged(dodged)

        if x > display_width - car_width or x < 0:
            crash()
            #gameExit = True

        #respawning of blocks in display
        if thing_starty > display_height:  
            thing_starty = 0 - thing_height
            thing_startx = random.randrange(0, display_width)
            dodged += 1
            thing_speed += 1
            thing_width += (dodged * 1.2)

        if y < thing_starty + thing_height:
            #print('Y_axis is crossed')

            if x > thing_startx and x < thing_startx + thing_width or x + car_width > thing_startx and x + car_width < thing_startx + thing_width:
                #print('X_axis is crossed')
                crash()

        
        
        pygame.display.update()
        clock.tick(60)

game_intro()
game_loop()
pygame.quit()
quit()
