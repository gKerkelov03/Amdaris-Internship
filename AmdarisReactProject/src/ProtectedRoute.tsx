import { Navigate, Outlet } from 'react-router-dom';

const ProtectedRoute = ({ isAuthenticated }: { isAuthenticated: boolean }) => {
    if (!isAuthenticated) {
        return <Navigate to="/landing" replace />;
    }

    return <Outlet />;
};

export default ProtectedRoute;
