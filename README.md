# X-ray Image Processing Project

This project is part of a university assignment aimed at developing a minimal software application for analyzing and editing chest X-ray images. The application is built using .NET and Windows Forms, focusing on providing a user-friendly interface for medical diagnostics.

## Features

- **Load X-ray Images**: Load X-ray images in various formats (JPEG, PNG, BMP).
- **Select Regions**: Click and drag to select regions on the X-ray images for targeted processing.
- **Apply Filters**: Apply various medically significant filters to the selected regions.
- **Save Images**: Save the edited X-ray images with applied filters.
- **Undo Operations**: Undo the last action performed.
- **History Tracking**: Maintain a history of applied filters and selections for easy tracking and modification.

## Installation

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/Mak-2002/xray-mm-project.git
    ```
2. **Open the Project**:
    - Open the solution file `XRayImageProcessor.sln` in Visual Studio.

3. **Build the Project**:
    - Build the solution to restore the dependencies and compile the project.

## Usage

1. **Load an X-ray Image**:
    - Click on the `Load X-ray Image` button and select an image file from your computer.
2. **Select a Region**:
    - Click and drag on the image to draw a rectangle around the region of interest.
3. **Apply a Filter**:
    - Select a filter from the dropdown menu and click `Apply Filter` to process the selected region.
4. **Save the Edited Image**:
    - Click on the `Save Image` button to save the processed image to your hard drive.
5. **Undo Last Action**:
    - Click on the `Undo` button to revert the last applied filter or action.

## Contributing

1. **Fork the Repository**:
    - Create a fork of this repository by clicking the "Fork" button.
2. **Create a Branch**:
    - Create a new branch for your feature or bugfix.
    ```bash
    git checkout -b feature-name
    ```
3. **Commit Your Changes**:
    - Commit your changes with a clear and concise message.
    ```bash
    git commit -m "Description of the feature or fix"
    ```
4. **Push to the Branch**:
    - Push your changes to the branch.
    ```bash
    git push origin feature-name
    ```
5. **Create a Pull Request**:
    - Open a pull request in the repository to review and merge your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Contact

For any questions or suggestions, feel free to reach out to me via GitHub or open an issue in the repository.
