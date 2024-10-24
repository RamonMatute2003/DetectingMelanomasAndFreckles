import os
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Conv2D, MaxPooling2D, Flatten
from tensorflow.keras.preprocessing.image import ImageDataGenerator

train_datagen = ImageDataGenerator(rescale=1./255, validation_split=0.2)
route = 'C:\\Users\\ramon\\OneDrive\\Programacion de juegos\\Fundamentos C#\\MelanomasAndFreckles\\'

train_generator = train_datagen.flow_from_directory(
    route + 'Sintomas',
    target_size=(150, 150),
    batch_size=8,
    class_mode='binary',
    subset='training')

validation_generator = train_datagen.flow_from_directory(
    route + 'Sintomas',
    target_size=(150, 150),
    batch_size=8,
    class_mode='binary',
    subset='validation')

model = Sequential([
    Conv2D(32, (3, 3), activation='relu', input_shape=(150, 150, 3)),
    MaxPooling2D(2, 2),
    Flatten(),
    Dense(128, activation='relu'),
    Dense(1, activation='sigmoid')
])

model.compile(optimizer='adam', loss='binary_crossentropy', metrics=['accuracy'])

model.fit(train_generator, epochs=10, validation_data=validation_generator)

model_path = os.path.join(route, 'melanoma_peca_model.keras')
model.save(model_path)
print(f"Modelo guardado en: {model_path}")