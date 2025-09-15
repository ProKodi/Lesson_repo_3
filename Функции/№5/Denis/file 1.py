






def red():
    global colors
    return f'Color is red - {colors[red]}'

def green():
    global colors
    return f'Color is green - {colors[green]}'

def blue():
    global colors
    return f'Color is blue - {colors[blue]}'


colors = {}
colors[green] = '00FF00'
colors[blue] = '0000FF'
colors[red] = 'FF0000'

for i in colors:
    print(i())