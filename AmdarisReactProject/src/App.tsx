import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import './App.css';
import ProtectedRoute from './ProtectedRoute';
import LandingPage from './components/LandingPage';
import LoginPage from './components/LoginPage';
import MainPage from './components/MainPage';
import RegisterPage from './components/RegisterPage';

const router = createBrowserRouter([
    {
        path: 'login',
        element: <LoginPage />
    },
    {
        path: 'register',
        element: <RegisterPage />
    },
    {
        path: 'landing',
        element: <LandingPage />
    },
    {
        element: (
            <ProtectedRoute isAuthenticated={!!localStorage.getItem('token')} />
        ),
        children: [
            {
                path: '/main',
                element: <MainPage />
            }
        ]
    },
    {
        path: '*',
        element: <p>404 Error - Nothing here...</p>
    }
]);

function App() {
    return (
        <>
            <RouterProvider router={router} />
        </>
    );
}

export default App;
