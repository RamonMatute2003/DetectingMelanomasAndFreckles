import sys
import os
import numpy as np

os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'

from tensorflow.keras.models import load_model
from tensorflow.keras.preprocessing import image
route = 'C:\\Users\\ramon\\OneDrive\\Programacion de juegos\\Fundamentos C#\\MelanomasAndFreckles\\'

model = load_model(os.path.join(route, 'melanoma_peca_model.keras'))
image_path = sys.argv[1]

img = image.load_img(image_path, target_size=(150, 150))
img_array = image.img_to_array(img)
img_array = np.expand_dims(img_array, axis=0)
img_array /= 255.0

prediction = model.predict(img_array, verbose = 0)

result = 'melanoma' if prediction[0][0] < 0.5 else 'peca'
print("La imagen es:", result)